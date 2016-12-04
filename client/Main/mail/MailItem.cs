using UnityEngine;
using System.Collections;

public enum MailType
{
    GM,
    Friend,
    Stranger
}

public class MailItem
{
    public int mailId;
    public string accountFrom;
    public string usernameFrom;
    public string content;
    public bool isRead;
    public MailType mailType;

    public MailItem(int mailId, string accountFrom, string usernameFrom, string content, bool isRead, MailType mailType)
    {
        this.mailId = mailId;
        this.accountFrom = accountFrom;
        this.usernameFrom = usernameFrom;
        this.content = content;
        this.isRead = isRead;
        this.mailType = mailType;
    }
}
