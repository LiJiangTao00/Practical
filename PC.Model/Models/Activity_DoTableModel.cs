using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
    /// <summary>
    /// �ִ�б�
    /// </summary>
    public class Activity_DoTableModel
	 {
        //�ִ�е�����
        public int  Id { get; set; }
        //�������ӻ�������
        public int  Activity_Do_Activity_Id { get; set; }
        //ҽԺ
        public string  Activity_Do_Hospital { get; set; }
        //��������û���
        public int  Activity_Do_User_Id { get; set; }
        //����ʱ��
        public DateTime  Activity_Do_CreateTime { get; set; }
        //����ʱ��
        public DateTime  Activity_Do_EndTime { get; set; }
        //�״̬
        public bool  Activity_Do_State { get; set; }
        //��������
        public string  Activity_Message_Desc { get; set; }
        //�����������������
        public int  Activity_Do_Con_Id { get; set; }
        //��������ӹ�ϵ��Ĳλ���Id(���ҹ�ϵ���������˵�����״̬Ϊ1���ǲλ�)
        public int  Activity_Do_Inviter_User_Id { get; set; }
        //�����ܽ�
        public string  Activity_Do_Final { get; set; }
        //������Ƭ
        public string  Activity_Do_Picture { get; set; }
	 }
}
