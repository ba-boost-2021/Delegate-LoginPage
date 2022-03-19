using BilgeAdam.ADONET.LoginPage.Extensions;
using BilgeAdam.Data.Abstractions;
using BilgeAdam.Data.Concretes;
using BilgeAdam.Data.Dtos;

namespace BilgeAdam.ADONET.LoginPage
{
    public partial class frm_Login : Form
    {
        private IAuthenticationService service;

        public frm_Login()
        {
            InitializeComponent();
            service = new AuthenticationService();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var dto = new CheckUserDto { Email = txtEmail.Text, Password = txtPassword.Text };
            var result = service.CheckUser(dto);

            if (result)
            {
                MessageBox.Show("Giri� ba�ar�l� :)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu bilgilerle oturum a��lamad� :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtEmail.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var frmRegister = new frmRegister(service);
            this.Switch(frmRegister);
            //if (reuslt == DialogResult.OK)
            this.Show();
        }

        // SecurityQuestions ad�nda bir tablo olu�turun. (Id, Questions(nvarchar(500)))
        // User tablosunda SecurityQuestionId ad�nda bir kolon (FK)
        // User tablosunda Answer kolon (g�venlik sorusunun cevab�)(nvarchar(64))




        // Register formu olu�turun. Kullan�c� bilgilerini al�n ve yeni bir kullan�c� insert edin
        // G�venlik sorular�n� bir combobox'ta listeleyin, kullan�c�n�n se�ti�i sorunun cevab�n� al�n. ve insert edin.



        // baseClass{ public string myProp {get; set;}}
        // childClass : baseClass{bi�eyler}
        // var instance = new childClass()
        // private void MyMethod(baseClass instance){..statements}
        //MyMethod(instance)





        // Bir login sayfas� dizayn� olu�turun.
        // Kullan�c� email ve password bilgilerini girsin
        // E�er db varsa b�yle bir kay�t(User Tablosu) giri� ba�ar�l� uyar�s�
        // yoksa Bu bilgilerle oturum a��lamad� uyar�s� versin
        /*
         @"CREATE TABLE Users(
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            FirstName NVARCHAR(64) NOT NULL,
                            LastName NVARCHAR(64) NOT NULL,
                            Email NVARCHAR(64) NOT NULL,
                            Password NVARCHAR(128) NOT NULL,
                            CreatedAt DATETIME NOT NULL,
                            CreatedBy NVARCHAR(64) NULL
                    )"
         */
    }
}