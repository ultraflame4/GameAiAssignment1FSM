public enum CosbotEmailType{
    SPAM,
    SPONSOR,
    COLLAB
}

public struct CosbotEmail{
    public string name;
    public CosbotEmailType type;
}