using System;

namespace KeepassAutoUnlock.Validation
{
    public abstract class AbstractConstraint
    {
        private Boolean _isValided = false;
        private ErrorLevel _errorLevel;

        public string Message { get; set; }

        public ErrorLevel IsValide()
        {
            if (_isValided)
            {
                return _errorLevel;
            }

            _isValided = true;
            _errorLevel = Validation();

            return _errorLevel;
        }

        protected abstract ErrorLevel Validation();
    }
}
