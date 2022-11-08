namespace Common.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string province, string city, string postalAddress)
    {
        Province = province;
        City = city;
        PostalAddress = postalAddress;
    }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalAddress { get; private set; }

    public Address Edit(string shire, string city, string postalAddress)
    {
        return new Address(shire, city, postalAddress);
    }

    public static Address EmptyAddress()
    {
        return new Address("", "", "");
    }

}