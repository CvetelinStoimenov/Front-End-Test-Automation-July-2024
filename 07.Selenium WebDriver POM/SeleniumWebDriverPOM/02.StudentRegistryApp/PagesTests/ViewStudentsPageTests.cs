using _02.StudentRegistryApp.Pages;

namespace _02.StudentRegistryApp.PagesTests
{
    public class ViewStudentsPageTests : BasePageTests
    {
        [Test]
        public void Test_ViewStudentsPage_Content() 
        {
            var ViewStudentsPage = new ViewStudentsPage(driver);
            ViewStudentsPage.Open();
            Assert.Multiple(() =>
            {
                Assert.That(ViewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
                Assert.That(ViewStudentsPage.GetPageHeadingText(), Is.EqualTo("Registered Students"));
            });
            var students = ViewStudentsPage.GetStudentsList();
            foreach (var st in students)
            {
                Console.WriteLine(st);
                Assert.Multiple(() =>
                {
                    Assert.That(st.IndexOf("(") > 0, Is.True);
                    Assert.That(st.LastIndexOf(")") == st.Length - 1, Is.True);
                });
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var ViewStudentsPage = new ViewStudentsPage(driver);

            // Click on the Home page link and assert the Home page is open
            ViewStudentsPage.Open();
            ViewStudentsPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            // Click on the Home page link and assert the Add Students Page is open
            ViewStudentsPage.Open();
            ViewStudentsPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            // Click on the Home page link and assert the View Students Page is open
            ViewStudentsPage.Open();
            ViewStudentsPage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
