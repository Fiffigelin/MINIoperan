class CustomerLogic
{
    public CustomerDB customerDB = new();
    private List<Customer> custList = new();
    public bool IsCustomer { get; set; }
    public bool BoolCustomerList(List<Customer> list)
    {
        if (list.Count > 0)
        {
            custList = list;
            return IsCustomer = true;
        }

        return IsCustomer = false;
    }
}