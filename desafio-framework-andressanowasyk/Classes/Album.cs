namespace desafio_framework_andressanowasyk
{
    public class Album
    {
        public int Id { get => Id; set => Id = value; }
        public string Title { get => Title; set => Title = value; }

        public Album(int id, string title)
        {
            Id = id;
            Title = title;
        }

    }



}

