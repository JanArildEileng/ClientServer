namespace CSShared.Dto;

public class InfoData {
    public Guid  Guid { get; set; }=Guid.NewGuid();
    public DateTime Created { get; set; }=DateTime.Now;

} 