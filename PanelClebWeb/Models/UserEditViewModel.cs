namespace PanelClebWeb.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
        public string Email { get; set; }
    }
}
