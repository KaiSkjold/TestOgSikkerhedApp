using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOgSikkerhedApp.Data;

public class CprUser
{
    [Key]
    public int cprId { get; set; }

    public string cprNum { get; set; }

    public string userName { get; set; }

}
