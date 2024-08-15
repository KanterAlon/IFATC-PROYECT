public class Feedback
{
    public int FeedbackId { get; set; }
    public int SessionId { get; set; }
    public int EvaluatorId { get; set; }
    public string? FeedbackText { get; set; } // Nullable string
    public DateTime FeedbackDate { get; set; } = DateTime.Now; // Initialize with current date/time
    
    // Navigation Properties
    public Session? Session { get; set; } // Nullable Session
    public User? Evaluator { get; set; } // Nullable User
}
