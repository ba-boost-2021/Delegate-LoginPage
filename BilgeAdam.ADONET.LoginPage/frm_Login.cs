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
                this.Switch(new frmProductManagement());
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

        private void button1_Click(object sender, EventArgs e)
        {
            var frmForgotPassword = new frmForgotPassword(service);
            this.Switch(frmForgotPassword);
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



        // Parolam� unuttum s�reci, ayr� bir formda olacak
        // Kullan�c�ya �nce Maili sorulacak. e�er b�yle bir mail varsa,
        // db den SecurityQuestions getirilecek
        // Ald���n�z cevap dbden do�rulanacak
        // parolay� s�f�rlamak i�in ayr� bir form a��lacak,
        // kullan�c� yeni parolas�n� girecek (passwordAgain olmal�)
        // kullan�c�n�n parolas� update edilecek (Hash ile)
    }
}








/*TODO: �DEVLER 19.03.2022-------SON TESL�M 23.03.2022 22:00 �ar�amba


�dev1 (kullan�c�n�n do�ru cevab� vermesi i�in 3 hakk� olsun yoksa hesab� bloke olsun);
Hesab�n bloke olmas� demek User tablosunda isActive kolonunun false olmas� demektir.
Bunun i�in User tablosuna boolean bir isActive kolonu ekleyin(Dbeaver ile yapabilirsiniz).
Default olarak hepsi aktif yani isActive = 1 olamal�
Bu implementasyondan sonra kullan�c�n�n giri� yapma senaryosunu de�i�tirin 
ve sadece aktif kullan�c�lar giri� yapabilir hale getirin.

�dev2 (�r�nleri listeledi�imiz sayfay� d�zenleyin)
D�zenlemeler �unlar� i�ermelidir;
  1) Paginating olmal� (sayfan�n alt�nda sa� sol ok tu�lar� olmal� ve veri par�a par�a gelmeli)(Bunu daha �nce yapt�n�z.)
  2) Sayfan�n �st k�sm�nda bulunan Product Search text box�n� �al���r hale getirin.
  3) Ekle, Sil, G�ncelle butonlar� Aktif hale getirin (Herbiri farkl� bir formda olmal�);


�NEML�: �devlerinizi ba-boost-2022 hesab�ndaki bu projenin repository'sini Fork lay�p kendi hesab�n�zda yap�n�z.
�devler sizlerin ki�isel hesaplar�n�zdaki repositorylerden kontrol edilecek. (Fork Nedir?)
*/