using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
    /// <summary>
    /// ��ӻ��
    /// </summary>
    public class ActivityTableModel
	 {
        //��ӻ������
        public int  Id { get; set; }
        //���������ͱ�
        public int  ActivityType_Id { get; set; }
        //�����
        public string  Activity_Name { get; set; }
        //�����
        public string  Activity_Desc { get; set; }
        //�ϴ�����
        public string  Activity_Data { get; set; }
        //�������Ʒ���
        public int  Activity_Product_Id { get; set; }
        //��������ű�
        public int  Acticity_Department_Id { get; set; }
        //��ɾ
        public int  Activity_DelState { get; set; }
        ///״̬
        public int ActivityState_Id { get; set; }
        //��ʼ
        public DateTime? TimeBegin { get; set; }
        //����
        public DateTime? TimeEnd { get; set; }
    }
}
