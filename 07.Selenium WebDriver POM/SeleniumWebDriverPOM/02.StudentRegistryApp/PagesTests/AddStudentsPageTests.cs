using _02.StudentRegistryApp.Pages;

namespace _02.StudentRegistryApp.PagesTests
{
    public class AddStudentsPageTests : BasePageTests
    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var AddStudentPage = new AddStudentPage(driver);
            AddStudentPage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(AddStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
                Assert.That(AddStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));
                Assert.That(AddStudentPage.FieldStudentName.Text, Is.EqualTo(""));
                Assert.That(AddStudentPage.FieldStudentEmail.Text, Is.EqualTo(""));
                Assert.That(AddStudentPage.ButtonAdd.Text, Is.EqualTo("Add"));
            });
        }

        [Test]
        public void Test_AddStudentPage_Links()
        {
            var AddStudentPage = new AddStudentPage(driver);

            // Click on the Home page link and assert the Home page is open
            AddStudentPage.Open();
            AddStudentPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            // Click on the Home page link and assert the Add Students Page is open
            AddStudentPage.Open();
            AddStudentPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            // Click on the Home page link and assert the View Students Page is open
            AddStudentPage.Open();
            AddStudentPage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            var AddStudentPage = new AddStudentPage(driver);
            AddStudentPage.Open();

            // Generate random name and email
            string name = GenerateRandomName();
            string email = GenerateRandomEmail(name);

            AddStudentPage.AddStudent(name, email);
            var viewStudents = new ViewStudentsPage(driver);
            Assert.That(viewStudents.IsOpen(), Is.True);
            var students = viewStudents.GetStudentsList();
            string newStudent = name + " (" + email + ")";
            Assert.That(students, Does.Contain(newStudent));
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            {
                var page = new AddStudentPage(driver);
                page.Open();
                string name = "";
                string email = "mario@gmail.com";
                page.AddStudent(name, email);
                Assert.Multiple(() =>
                {
                    Assert.That(page.IsOpen(), Is.True);
                    Assert.That(page.ElementErrorMsg.Text, Does.Contain("Cannot add student."));
                });
            }
        }

        // Method to generate a random name
        private string GenerateRandomName()
        {
            var random = new Random();
            string[] names = { "Mario", "Luigi", "Peach", "Toad", "Yoshi" };
            return names[random.Next(names.Length)] + random.Next(1000, 9999).ToString();
        }

        // Method to generate a random email
        private string GenerateRandomEmail(string name)
        {
            var random = new Random();
            string domain = "@gmail.com";
            return name.ToLower() + random.Next(1000, 9999).ToString() + domain;
        }
    }
}