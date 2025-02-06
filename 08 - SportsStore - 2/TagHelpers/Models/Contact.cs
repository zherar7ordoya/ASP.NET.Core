namespace ContactManager.Models;


public class Contact(Guid id, string? name, string? email, string? phone, string? address)
{
    public Guid Id { get; set; } = id;

    public string? Name { get; set; } = name;

    public string? Email { get; set; } = email;

    public string? Phone { get; set; } = phone;

    public string? Address { get; set; } = address;
}
