namespace H1W2D3ToDoOrNotToDo
{
    internal class Menu
    {
        List<ToDoItem> todoList = new();

        //Constructor that runs when object is instantiated (with new keyword).
        public Menu()
        {
            FakeData();
            while (true)
            {
                MainMenu();
            }
        }

        private void FakeData()
        {
            for (int i = 0; i < 5; i++)
            {
                ToDoItem tdi = new ToDoItem() { Created = DateTime.Now, Deadline = DateTime.Now.AddDays(1), Description = "Something " + i};
                todoList.Add(tdi);
            }
        }

        //Start menu
        public void MainMenu()
        {
            Console.WriteLine("\nMain Menu\n\n(1) Add new\n(2) Show List\n(3) Update Item\n");

            var v = Console.ReadKey(true);
            switch (v.KeyChar)
            {
                case '1':
                    CreateItem();
                    break;
                case '2':
                    ShowList();
                    break;
                case '3':
                    UpdateItem();
                    break;
                default:
                    break;
            }
        }

        //Show TodoList shows TodoItems
        void ShowList()
        {
            foreach (ToDoItem? item in todoList)
            {
                ShowItem(item);
            }
        }

        //Create Item
        private void CreateItem()
        {
            ToDoItem newItem = new ToDoItem();
            newItem.Created = DateTime.Now;

            Console.WriteLine("What to do?");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("When to do it?");
            string dl = Console.ReadLine();
            //TODO Get different input regarding dates and times
            newItem.Deadline = DateTime.Parse(dl);
            newItem.IsDone = false;

            Console.WriteLine("Is it important?");
            newItem.IsFavorite = Console.ReadKey(true).Key == ConsoleKey.Y ? true : false;

            todoList.Add(newItem);
        }

        //Read TodoItem
        private void ShowItem(ToDoItem toDoItem)
        {
            int i = todoList.IndexOf(toDoItem);
            Console.WriteLine($"index: {i} \tWhat: {toDoItem.Description} \tWhen: {toDoItem.Deadline} \tisDone: {toDoItem.IsDone}");
            //Console.WriteLine("What: {0} When: {1} isDone: {2}", toDoItem.Todo, toDoItem.Deadline, toDoItem.IsDone);
            //Console.WriteLine("What: " + toDoItem.Todo + "When: " + toDoItem.Deadline + "isDone: " + toDoItem.IsDone);
        }


        //Update Item
        void UpdateItem()
        {
            Console.WriteLine("Update. Pick item index for todoitem that needs updating");
            ShowList();
            int i = int.Parse(Console.ReadLine());
            ToDoItem tdi = todoList[i];
            Console.WriteLine("What to do?");
            string input = Console.ReadLine();
            if (input != "")
                tdi.Description = input;

        }

        //Delete Item




    }
}
