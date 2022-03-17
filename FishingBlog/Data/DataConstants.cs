namespace FishingBlog.Data
{

    public class DataConstants
    {

        public class Topic
        {
            public const int TitleMaxLength = 200;
        }

        public class Publication
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 200;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 5000;
        }

        public class Comment
        {
            public const int DefaultMaxLength = 20;
            public const int DescriptionMaxLength = 5000;
        }

        public class Product
        {
            public const int BrandMaxLength = 15;
            public const int ModelMaxLength = 30;
            public const int DescriptionMaxLength = 5000;
        }


        public class Administrator
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
        }

    }
}