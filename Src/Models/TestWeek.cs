namespace NorwegianRowingAssociation.Models;

public partial class TestWeek
{
    public int Id { get; set; }

    public int Number { get; set; }

    public virtual ICollection<TestResult> TestResults { get; set; } = [];
}