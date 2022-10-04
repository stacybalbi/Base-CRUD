

using Base_CRUD;
using Base_CRUD.Entidades;
using Base_CRUD.Servicios;


Console.WriteLine("Hello, World!");
//Hacer Menu dinamico que permita hacer el CRUD

var personServices = new PersonService();

var persona1 = new Person()
{
    Name = "Adrian",
    sex = Sex.male,
    Birthday = DateTime.Now
};
var persona2 = new Person()
{
    Name = "Alicia",
    sex = Sex.female,
    Birthday = Convert.ToDateTime("2007/07/02")
};

var personCreated = personServices.Create(persona1);
var personCreated2 = personServices.Create(persona2);

Console.WriteLine($"{personCreated.ID} | {personCreated.Name} | {personCreated.sex}");

Console.WriteLine("Personas creadas correctamente");

