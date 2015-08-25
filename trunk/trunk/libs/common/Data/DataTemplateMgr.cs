
/**
 * @file DataTemplateMgr.cs
 * @brief 数据模板管理器
 *              负责：
 *                      定义数据接口
 *                      使用Dictionary存储数据
 *
 *
 * @author lixiaojiang
 * @version 1.0.0
 * @date 2012-12-16
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;

namespace Zigzag.Common
{

    /**
     * @brief 数据接口
     */
    interface IData
    {

        /**
         * @brief 提取数据
         *
         * @param node
         *
         * @return 
         */
        bool CollectDataFromXml(XmlNode node);

        /**
         * @brief 获取数据ID
         *
         * @return 
         */
        string GetId();
    }

    /**
     * @brief 数据模板管理器
     */
    class DataTemplateMgr<TData> where TData : IData, new()
    {
        //---------------------------------------------------------
        // 属性
        //---------------------------------------------------------

        /**
         * @brief 数据容器，默认使用字典
         */
        Dictionary<string, TData> m_DataContainer;

        /**
         * @brief 构造函数
         *
         * @return 
         */
        public DataTemplateMgr()
        {
            m_DataContainer = new Dictionary<string, TData>();
        }

        /**
         * @brief 提取数据
         *
         * @param file 文件路径，xml文件必须顶层节点为"Include"
         *
         * @return 
         */
        public bool CollectDataFromXml(string file)
        {
            bool result = true;

            XmlDocument document = new XmlDocument();
            document.Load(file);
            XmlNode root = document.SelectSingleNode("Include");
            Debug.Assert(root != null, "DataTempalteMgr.CollectDataFromXml Include is not Exist!");

            XmlNodeList nodeList = root.ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                TData data = new TData();
                bool ret = data.CollectDataFromXml(node);
                Debug.Assert(ret, "DataTempalteMgr.CollectDataFromXml collectData:{0} failed!", node.Name);
                if (ret)
                {
                    m_DataContainer.Add(data.GetId(), data);
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        /**
         * @brief 获取数据，根据ID
         *
         * @param id
         *
         * @return 
         */
        public TData GetDataById(string id)
        {
            if (m_DataContainer.ContainsKey(id))
            {
                return m_DataContainer[id];
            }

            return default(TData);
        }

        /**
         * @brief 获取数据数量
         *
         * @param id
         *
         * @return 
         */
        public int GetDataCount()
        {
            return m_DataContainer.Count;
        }
    }


    //---------------------------------------------------------
    // 单元测试
    //---------------------------------------------------------

    /**
     * @brief 测试数据
     */
    class Data_Test : IData
    {
        public string m_Id;
        public string m_Name;

        public virtual string GetId()
        {
            return m_Id;
        }

        public virtual bool CollectDataFromXml(XmlNode node)
        {
            m_Id = XmlUtil.ExtractString(node, "Id", "", true);
            m_Name = XmlUtil.ExtractString(node, "Name", "", true);

            return true;
        }
    }

    /**
     * @brief 测试类
     */
    class UnitTest_DataTemplateMgr
    {

        /**
         * @brief 测试入口
         *
         * @param args
         */
        static void Main(string[] args)
        {
            DataTemplateMgr<Data_Test> m_DataSceneMgr = new DataTemplateMgr<Data_Test>();
            bool ret = m_DataSceneMgr.CollectDataFromXml(@".\Res\Scenes.xml");
            Console.WriteLine("Collect:{0}, DataCount:{1}", ret, m_DataSceneMgr.GetDataCount());

            Data_Test test = m_DataSceneMgr.GetDataById("0");
            Console.WriteLine("Id:{0} Name:{1}", test.m_Id, test.m_Name);

            Data_Test test2 = m_DataSceneMgr.GetDataById("100");
            if (test2 == null)
            {
                Console.WriteLine("Check Try to GetData not Exist success!");
            }
            else
            {
                Console.WriteLine("Check Try to GetData not Exist failed!");
            }

            Console.ReadKey();
        }
    }
}
