namespace Cleverence.Test.Task2;

#region Наиболее простой вариант через Interlocked (хотя и противоречит условию "пока писатели добавляют и пишут, читатели должны ждать окончания записи")

public static class Server
{
    private static int _count;

    public static int GetCount()
    {
        return _count;
    }

    public static int AddToCount(int value)
    {
        return Interlocked.Add(ref _count, value);
    }
}

#endregion

#region Вариант через ReaderWriterLockSlim

public static class ServerV2
{
    private static readonly ReaderWriterLockSlim _readerWriterLockSlim = new();

    private static int _count;

    public static int GetCount()
    {
        _readerWriterLockSlim.EnterReadLock();

        try
        {
            return _count;
        }
        finally
        {
            _readerWriterLockSlim.ExitReadLock();
        }
    }

    public static int AddToCount(int value)
    {
        _readerWriterLockSlim.EnterWriteLock();

        try
        {
            return _count += value;
        }
        finally
        {
            _readerWriterLockSlim.ExitWriteLock();
        }
    }
}

#endregion
