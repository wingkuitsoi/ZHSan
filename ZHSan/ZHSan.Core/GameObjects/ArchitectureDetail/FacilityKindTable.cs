using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail
{
    [DataContract]
    public class FacilityKindTable
    {
        [DataMember]
        public Dictionary<int, FacilityKind> FacilityKinds = new Dictionary<int, FacilityKind>();
    
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="facilityKind"></param>
        /// <returns></returns>
        public bool Add(FacilityKind facilityKind)
        {
            return FacilityKinds.TryAdd(facilityKind.ID, facilityKind);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            return FacilityKinds.Remove(id);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FacilityKind Get(int id)
        {
            FacilityKinds.TryGetValue(id, out var kind);
            return kind;
        }

        public int Count => FacilityKinds.Count;

        public GameObjectList GetFacilityKindList() => [.. FacilityKinds.Values];

        public void Clear() => FacilityKinds.Clear();

        public string SaveToString() => string.Join(" ", FacilityKinds.Values.Select(x => x.ID));

        /// <summary>
        /// 最大占用位置
        /// </summary>
        /// <returns></returns>
        public int GetMaxFacilityPosition() => FacilityKinds.Values.Max(x => x.PositionOccupied);
    }
}