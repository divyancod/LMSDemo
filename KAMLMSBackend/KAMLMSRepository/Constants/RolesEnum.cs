namespace KAMLMSRepository.Constants
{
    public enum Role
    {
        Admin = 1,
        Director = 2,
        Manager = 3,
        SalesManager = 4,
        AssistantManager = 5,
        OperationsManager = 6,
        Receptionist = 7,
        BarManager = 8,
        CustomerServiceManager = 9,
        ITAuthority = 10,
        Custom = 11
    }

    public enum LeadStatus
    {
        New = 1,
        InProgress = 2,
        FollowUp = 3,
        ClosedWon = 4,
        ClosedLost = 5
    }

    public enum CallStatusEnum
    {
        Scheduled=1,
        ReScheduled=2,
        Completed=3,
        Waiting=4,
        Answered=5,
        NotAnswered=6,
        Cancelled=7
    }
}
