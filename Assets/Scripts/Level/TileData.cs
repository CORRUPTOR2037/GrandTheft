using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TileData {

    protected bool filled = true;
    protected int state = 0;
    protected Color variant;
    protected Entity content;
    protected string Name = "cliff";
    protected int TimeInterval = 0;
    private int ContentIndex;

    public static Tilemap map;

    protected Vector3Int pos;

    public bool Filled { get { return filled; } }
    public bool HasContent { get { return content != null; } }
    public int State { get { return state; } }
    public string Variant {
        get; private set;
    }
    public TileData(int x, int y, int state)
    {
        this.state = state;
        ContentIndex = Random.Range(0, 2);
        pos = new Vector3Int(x, y, 0);
        SetVariant("Blue");
        Update();
    }

    public int x { get { return pos.x; } }
    public int y { get { return pos.y; } }

    public Vector2Int Position => new Vector2Int(x, y);

    public void SetFilled(bool value)
    {
        filled = value;
        Update();
    }

    public void SetTimePosition (int value) {
        TimeInterval = value;
        LoadContent();
        Update();
    }

    public void SetVariant(string variant)
    {
        Variant = variant;
        switch (variant)
        {
            case "Red": this.variant = new Color(1.0f, 0.8f, 0.8f); break;
            case "Blue": this.variant = new Color(0.8f, 0.8f, 1.0f); break;
            case "Green": this.variant = new Color(0.8f, 1.0f, 0.8f); break;
            case "Yellow": this.variant = new Color(1.0f, 1.0f, 0.8f); break;
            case "Magenta": this.variant = new Color(1.0f, 0.8f, 1.0f); break;
            case "Aqua": this.variant = new Color(0.8f, 0.9f, 1.0f); break;
            case "No": this.variant = Color.white; break;
            default: throw new System.Exception("Unknown variant: " + variant);
        }
        Update();
    }

    public void SetState(int index)
    {
        state = index;
        LoadContent();
        Update();
    }

    public Entity.OnTrigger onTrigger {
        get { return content.onTrigger; }
        set { content.onTrigger = value; }
    }

    public void SetContent(bool value)
    {
        if (value && content == null) {
            content = Resources.Load<Entity>("Entities/TileContent");
            content = Object.Instantiate(content);
            content.gameObject.name = x + "-" + y + " Content";
            content.transform.parent = map.transform;
        }
        if (!value) {
            Object.Destroy(content);
            content = null;
        }
        LoadContent();
        Update();
    }

    int currentState { get {
            if (state < 0) return state;
            return Mathf.Max(0, state - TimeInterval);
    } }

    private void LoadContent()
    {
        if (content == null) return;
        float offset = 0;
        switch (state) {
            case 1: offset = 0.08f; break;
            case 2: offset = 0.04f; break;
        }
        content.SetPosition(x, y, -offset);

        string name = "trees" + ContentIndex + "_" + (state >= 0 ? "warm" : "cold");
        foreach (Sprite s in Resources.LoadAll<Sprite>("Trees")) {
            if (s.name == name){
                content.SetSprite(s);
                break;
            }
        }
    }

    public void Update()
    {
        if (!filled || currentState == 0){
            map.SetTile(pos, null);
            return;
        }
        string name = Name;
        if (currentState == 2) name += "_break1";
        if (currentState == 1) name += "_break2";
        Tile tile = Resources.Load<Tile>("Tiles/" + name);
        map.SetTile(pos, tile);
        map.SetTileFlags(pos, TileFlags.None);
        map.SetColor(pos, variant);
    }

    public virtual bool CanStandOn(int x, int y) {
        if (!Filled) return false;
        if (currentState == 0) return false;
        if (HasContent) return false;
        return true;
    }
}
