namespace Unknown.Koala.Domain.Catalog
{
    public class Rating 
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }
        
        public Rating(int stars, string userName, string review) 
        {
            if (stars < 1 || stars > 5)
            {
                throw new ArgumentException("Star rating must be an integer of: 1, 2, 3, 4, 5.");
            }

            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Username cannot be null or empty.");
            }

            this.Stars = stars;
            this.UserName = userName;
            this.Review = review;
        }
    }
}
