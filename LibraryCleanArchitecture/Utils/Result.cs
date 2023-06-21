namespace DomainClean.Utils
{
    public abstract class Result<ERR, OK> where ERR : class where OK : class
    {
        public bool IsOk => this is Ok<ERR, OK>;
        public bool IsErr => this is Err<ERR, OK>;

        public ERR Error
        {
            get
            {
                if (IsErr)
                {
                    return (this as Err<ERR, OK>).Error;
                }
                else
                {
                    throw new InvalidOperationException("Cannot get error from Ok result.");
                }
            }
        }

        public OK Value
        {
            get
            {
                if (IsOk)
                {
                    return (this as Ok<ERR, OK>).Value;
                }
                else
                {
                    throw new InvalidOperationException("Cannot get value from Err result.");
                }
            }
        }
        
        public static implicit operator Result<ERR, OK>(ERR err) => new Err<ERR, OK>(err);

        public static implicit operator Result<ERR, OK>(OK ok) => new Ok<ERR, OK>(ok);

        public static implicit operator bool(Result<ERR, OK> result) => result.IsOk;

        public Result<ERR_OUT, OK_OUT> map<ERR_OUT, OK_OUT>(Func<ERR, ERR_OUT> errFunc, Func<OK, OK_OUT> okFunc) where ERR_OUT : class where OK_OUT : class
        {
            if (IsErr)
            {
                return errFunc(Error);
            }
            else
            {
                return okFunc(Value);
            }
        }
    }

    internal class Err<ERR, OK> : Result<ERR, OK> where ERR : class where OK : class
    {
        public new ERR Error { get; }

        public Err(ERR error)
        {
            Error = error;
        }

        override public string ToString() => $"Err: {Error}";
    }

    internal class Ok<ERR, OK> : Result<ERR, OK> where ERR : class where OK : class
    {
        public new OK Value { get; }

        public Ok(OK value)
        {
            Value = value;
        }

        override public string ToString() => $"Ok: {Value}";
    }
}
