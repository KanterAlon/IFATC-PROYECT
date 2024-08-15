public class Session
{
    public int SessionId { get; set; }
    public int TrainerId { get; set; }
    public int TraineeId { get; set; }
    public DateTime SessionDate { get; set; }
    
    // Navigation Properties
    public User? Trainer { get; set; } // Nullable User
    public User? Trainee { get; set; } // Nullable User
}
