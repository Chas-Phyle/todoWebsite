using todoWebsite.Models;
using todoWebsite.Pages;

namespace todoWebsite.Tests
{
    public class UnitTest1
    {
        public DataAccess test = new DataAccess();

        /// <summary>
        /// A test to make sure the user will be able to add tasks to the database
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AddingANewTaskTest()
        {
            //Setting up required information for checking the database size
            var sql = "Select * from tasks";
            //Geting the whole database
            List<TaskModel> taskDB = await test.LoadData<TaskModel, dynamic>(sql, new { }, "Server=127.0.0.1;database=todolist;uid=root;pwd=Cp8520123789");
            //Counting the size of the DB
            var totalTasksBeforeTest = taskDB.Count;

            //setting up the test 
            using var ctx = new TestContext();
            //Rendering in everyting on the webpage AddTasks
            var component = ctx.RenderComponent<AddTasks>();
            //Looking for the button on the webpage and clicking it
            component.Find("button").Click();

            //Clearing the database List so we can compare the size of the new database 
            taskDB.Clear();

            taskDB = await test.LoadData<TaskModel, dynamic>(sql, new { }, "Server=127.0.0.1;database=todolist;uid=root;pwd=Cp8520123789");

            var totalTasksAfterTest = taskDB.Count;

            //Checking to make sure that the size of the Task List is not the same anymore
            Assert.NotEqual(totalTasksBeforeTest, totalTasksAfterTest);

        }
    }
}