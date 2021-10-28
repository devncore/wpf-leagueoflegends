﻿using Lol.Database.Common;
using Lol.Database.Entites.Core;
using Lol.Database.Entites.Schema;

namespace Lol.Database.Controller
{
    public class ChampApi : LolDbContext
    {
        #region GetChamps

        public List<Champs> GetChamps()
        {
            var query = from c in Db.Champs
                        select new Champs
                        {
                            Seq = c.Seq,
                            Champ = c.Champ,
                            Name = c.Name,
                            Img = ResourceHelper.ImgResource(c.Img),
                            Insignia = ResourceHelper.ImgResource(c.Insignia),
                            영원석 = c.영원석
                        };
            return query.ToList();
        }
        #endregion

        #region GetChampCb1

        public List<ChampCb> GetChampCb1()
        {
            var query = from c in Db.ChampCb
                        where c.Type == 0
                        select new ChampCb
                        {
                            Seq = c.Seq,
                            Content = c.Content,
                            Type = c.Type
                        };
            return query.ToList();
        }
        #endregion

        #region GetChampCb2

        public List<ChampCb> GetChampCb2()
        {
            var query = from c in Db.ChampCb
                        where c.Type == 1
                        select new ChampCb
                        {
                            Seq = c.Seq,
                            Content = c.Content,
                            Type = c.Type
                        };
            return query.ToList();
        }
        #endregion

        public List<ChampHeaders> GetChampHeaders()
        {
            Db.ChampItems.ForEach(x => x.Img = ResourceHelper.ImgResource(x.Img));

            var query = from c in Db.ChampHeaders
                        select new ChampHeaders
                        {
                            Seq = c.Seq,
                            ChampCbSeq = c.ChampCbSeq,
                            Children = Db.ChampItems.Where(x => x.HeaderSeq == c.Seq).ToList(),
                            Header = c.Header,
                            IsExpanded =  c.IsExpanded
                        };

            return query.ToList();
        }



    }
}
