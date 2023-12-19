namespace HR_Project.Presentation.Models.VMs
{
    public class CreateExpenseVM
    {
        public decimal Amount { get; set; }
        public int ExpenseTypeID { get; set; }
        public string CurrencyCode { get; set; }
        public int PersonnelID { get; set; }
        public string DocumentPath { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
