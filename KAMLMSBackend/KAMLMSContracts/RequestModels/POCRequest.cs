namespace KAMLMSContracts.RequestModels
{
    public class POCRequest
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string? CustomRole { get; set; }
        public bool? IsMainPOC { get; set; }
    }
}
