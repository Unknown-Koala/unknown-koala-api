namespace Unknown.Koala.Domain.Catalog;

public class Rating 
{
    public int Stars { get; set; }
    public string UserName { get; set; }
    public string Review { get; set; }
}

public Rating(int stars, string userName, string review) 
{
    if (Stars < 1 || stars > 5)
    {
        throw new ArgumentException("Star rating must be an integer of: 1, 2, 3, 4, 5.");
    }

    if(string.IsNullOrEmpty(UserName))
    {
        throw new ArgumentException("Username cannot be null.");
    }

    this.Stars = stars;
    this.UserName = UserName;
    this.Review = review;
}