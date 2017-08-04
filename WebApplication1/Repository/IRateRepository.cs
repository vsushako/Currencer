using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IRateRepository
    {
        /// <summary>
        /// ������ ���� ������
        /// </summary>
        /// <returns>������ ������</returns>
        IQueryable<Rate> Get();

        /// <summary>
        /// ������������ ����
        /// </summary>
        /// <param name="id">������������� �����</param>
        /// <returns>����</returns>
        Rate Get(Guid id);

        /// <summary>
        /// �������� �������� �����
        /// </summary>
        /// <param name="currencyId">����</param>
        /// <param name="value">�������� ������</param>
        /// <param name="date">���� ���������</param>
        /// <returns>����</returns>
        Task<Rate> Create(Guid currencyId, float value, DateTime date);

        /// <summary>
        /// �������� �����
        /// </summary>
        /// <param name="rate">����</param>
        void Remove(Rate rate);

    }
}