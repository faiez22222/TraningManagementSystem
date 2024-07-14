using System;
using System.Web;

public class Batch
{
	public int BatchId { get; set; }
	public string CourseName { get; set; }
	public DateTime StarDate { get; set; }
	public DateTime  EndDate { get; set; }
	public string Instructor { get; set; }
	public string Status { get; set; }
}