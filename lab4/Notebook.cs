namespace lab4
{
    public class NoteBook
    {
        private List<Contact> _contacts = new List<Contact>();

        public void AddNewContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }
    }
}
