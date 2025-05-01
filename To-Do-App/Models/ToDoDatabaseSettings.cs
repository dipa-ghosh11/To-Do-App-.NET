using System;

namespace To_Do_App.Models{

public class ToDoDatabaseSettings
{
    public  required  string ConnectionString { get; set;}   
    public  required string DatabaseName { get; set;}
    public  required string UserCollectionName { get; set; }
    public  required string TaskCollectionName { get; set; }
}
}

