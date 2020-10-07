using System.Collections.Generic;
using System.Windows.Forms;
using KeePassAutoUnlock.Config;
using KeePassAutoUnlock.Exception;

namespace KeePassAutoUnlock.Validation
{
    public class Validator
    {
        private bool _isValidated;
        private ErrorLevel _errorLevel;
        private CheckBox _enableValue;
        private readonly ICollection<AbstractConstraint> _allConstraints;
        private readonly ICollection<AbstractConstraint> _errors;

        public Validator(CheckBox enableValue)
        {
            _isValidated = false;
            _errorLevel = ErrorLevel.GOOD;
            _enableValue = enableValue;
            _allConstraints = new List<AbstractConstraint>();
            _errors = new List<AbstractConstraint>();
        }

        private void Validation()
        {
            if (_isValidated || !IsEnabled())
            {
                return;
            }

            _isValidated = true;

            foreach (AbstractConstraint c in _allConstraints)
            {
                ErrorLevel el = c.IsValide();
                _errorLevel = (_errorLevel > el)
                    ? el
                    : _errorLevel
                ;

                if (el == ErrorLevel.GOOD)
                {
                    continue;
                }

                _errors.Add(c);
            }
        }

        public Validator AddConstraint(AbstractConstraint c)
        {
            if (_isValidated)
            {
                throw new UnexpectedCall();
            }

            _allConstraints.Add(c);
            return this;
        }

        public ErrorLevel GetErrorLevel()
        {
            Validation();

            return _errorLevel;
        }

        public ICollection<AbstractConstraint> GetErrors()
        {
            Validation();

            return _errors;
        }

        public string GetFullMessage()
        {
            Validation();

            if (_errorLevel == ErrorLevel.GOOD)
            {
                return "";
            }

            string r = "KeePassAutoUnlock :";

            foreach (AbstractConstraint c in GetErrors())
            {
                ErrorLevel el = c.IsValide();

                r += "\n";

                if (el == ErrorLevel.ERROR)
                {
                    r += "Error : ";
                }
                else if(el == ErrorLevel.WARNING)
                {
                    r += "Warning : ";
                }

                r += c.Message;
            }

            return r;
        }

        private bool IsEnabled()
        {
            if (_enableValue != null)
            {
                return _enableValue.Checked;
            }

            PluginConfig customConfig = PluginConfig.Instance;
            return customConfig.IsEnabled.Get();
        }
    }
}
