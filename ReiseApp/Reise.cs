using SQLite;

namespace ReiseApp;

[Table("Reise")]

public class Reise
{

    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("Vorname")]
    public string Vorname { get; set; }

    [Column("Nachname")]
    public string Nachname { get; set; }


    [Column("Ort")]
    public string Ort {  get; set; }


    [Column("Datum")]
    public string Datum { get; set; }


}
