namespace SparkSwim.GoodsService;

public class DbInitializer
{
    public static void Initialize(EcoDbContext context)
    {
        context.Database.EnsureCreated();       
    }
}