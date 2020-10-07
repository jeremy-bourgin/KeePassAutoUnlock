using System.IO;
using System.Windows.Forms;

using KeepassAutoUnlock.Validation;

namespace KeepassAutoUnlock.Constraints
{
    // permet de vérifier si le chemin entré vers la base de donnée est valide
    public class DatabaseConstraint : AbstractConstraint
    {
        private readonly TextBox _databaseLocationValue;

        public DatabaseConstraint(TextBox databaseLocationValue)
        {
            Message = "The database file doesn't exist";
            _databaseLocationValue = databaseLocationValue;
        }

        protected override ErrorLevel Validation()
        {
            return (File.Exists(_databaseLocationValue.Text))
                ? ErrorLevel.GOOD
                : ErrorLevel.ERROR
            ;
        }
    }
}
