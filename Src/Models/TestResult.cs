namespace NorwegianRowingAssociation.Models;

public partial class TestResult
{
	public int Id { get; set; }

	public float? Score { get; set; }

	public string? Time { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? UpdatedDate { get; set; }

	public int TestId { get; set; }

	public int TestWeekId { get; set; }

	public int UserId { get; set; }

	public virtual Test? Test { get; set; }

	public virtual TestWeek? TestWeek { get; set; }

	public virtual User? User { get; set; }
}
