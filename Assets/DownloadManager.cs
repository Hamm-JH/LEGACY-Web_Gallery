using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UnityAASample
{
    public class DownloadManager : MonoBehaviour
    {
        //로컬용. 신경쓰지 않아도 됩니다.
        [SerializeField] private AssetReference[] assetsObjects;

        //스타트에서 어드레서블 이니셜을 하는데 무효한 핸들이라고 자꾸 나와서 일단 없애두었습니다.
        //IEnumerator Start()
        //{
        //    Debug.Log("Start Already Gone");
        //    var InitAddressablesAsync = Addressables.InitializeAsync();
        //    yield return InitAddressablesAsync;
        //    yield return UpdateCatalogCoro();
            
        //}

        //전체 어드레서블 업데이트.
        public void UpdateAllAddressablsGroups()
        {
            StartCoroutine(UpdateAllGroupsCoro());
        }
        //라벨 단위 다운로드.
        public void LabelDownloadAsset(string label)
        {
            StartCoroutine(UpdateLabelAsset(label));
        }

        //로컬과 서버 같이 다운로드인 것으로 보임.
        public void MultipleDonwloadAssets()
        {
            StartCoroutine(MultipleDonwloadAssets(assetsObjects));
        }
        //전체 에셋 클리어. (이 과정이 반드시 필요합니다. 처음에.그리고 나중에.)
        public void ClearAllAsset()
        {
            StartCoroutine(ClearAllAssetCoro());
        }
        //라벨단위 에셋 클리어.
        public void ClearLabelAsset(string label)
        {
            StartCoroutine(ClearAssetCoro(label));
        }
        //로컬+서버 에셋 클리어.
        public void ClearMultipleAssets()
        {
            StartCoroutine(ClearAssetCoro(assetsObjects));
        }

        #region Update Catalog
        IEnumerator UpdateCatalogCoro()
        {
            List<string> catalogsToUpdate = new List<string>();
            var checkCatalogHandle = Addressables.CheckForCatalogUpdates();
            yield return checkCatalogHandle;

            if (checkCatalogHandle.Status == AsyncOperationStatus.Succeeded)
                catalogsToUpdate = checkCatalogHandle.Result;

            if (catalogsToUpdate.Count > 0)
            {
                var updateCatalogHandle = Addressables.UpdateCatalogs(catalogsToUpdate, false);
                yield return updateCatalogHandle;
            }
        }
        #endregion

        #region Update All Asset
        IEnumerator UpdateAllGroupsCoro()
        {
            foreach (var loc in Addressables.ResourceLocators)
            {
                foreach (var key in loc.Keys)
                {
                    var sizeAsync = Addressables.GetDownloadSizeAsync(key);
                    yield return sizeAsync;
                    long totalDownloadSize = sizeAsync.Result;

                    if (sizeAsync.Result > 0)
                    {
                        var downloadAsync = Addressables.DownloadDependenciesAsync(key);
                        while (!downloadAsync.IsDone)
                        {
                            float percent = downloadAsync.PercentComplete;
                            Debug.Log($"{key} = percent {(int)(totalDownloadSize * percent)}/{totalDownloadSize}");
                            yield return new WaitForEndOfFrame();
                        }
                        Addressables.Release(downloadAsync);
                    }
                    Addressables.Release(sizeAsync);
                }
            }
            Debug.Log("Download All Asset finish");
        }
        #endregion

        #region Update label Asset
        IEnumerator UpdateLabelAsset(string label)
        {
            long updateLabelSize = 0;
            var async = Addressables.GetDownloadSizeAsync(label);
            yield return async;
            if (async.Status == AsyncOperationStatus.Succeeded)
            {
                updateLabelSize = async.Result;
                Addressables.Release(async);
                Debug.Log("succeeded :" + updateLabelSize);
            }
               
            if (updateLabelSize == 0)
            {
                Debug.Log($"{label} last version");
                yield break;
            }
            yield return DownloadLabelAsset(label);
        }
        //다운로드 퍼센트가 여기에 나옵니다.
        IEnumerator DownloadLabelAsset(string label)
        {
            Debug.Log("DownloadLabel?");
            var downloadAsync = Addressables.DownloadDependenciesAsync(label, false);

            while (!downloadAsync.IsDone)
            {
                float percent = downloadAsync.PercentComplete;
                Debug.Log($"{label}: {downloadAsync.PercentComplete * 100} %");
                yield return new WaitForEndOfFrame();
            }
            Addressables.Release(downloadAsync);

           
            Debug.Log($"{label} UpdateAssets finish");
        }
        #endregion
        //로컬에셋 쓸 것 아니면 불필요.
        #region Updata Multiple Assets

        IEnumerator MultipleDonwloadAssets(AssetReference[] assets)
        {
            var assetKeys = assets.Cast<AssetReference>();
            var updateSizeHandle = Addressables.GetDownloadSizeAsync(assetKeys);
            long updateSize = 0;
            if (updateSizeHandle.Status == AsyncOperationStatus.Succeeded)
                updateSize = updateSizeHandle.Result;

            if (updateSize > 0)
            {
                var updateHandle = Addressables.DownloadDependenciesAsync(assetKeys, Addressables.MergeMode.Union);
                while (!updateHandle.IsDone)
                {
                    var st = updateHandle.GetDownloadStatus();
                    float percent = (float)st.DownloadedBytes / (float)st.TotalBytes;
                    Debug.Log(" Multiple Download percent " + percent);
                    yield return new WaitForEndOfFrame();
                }

                if (updateHandle.Status == AsyncOperationStatus.Succeeded)
                    Debug.Log(" Multiple Download Succeeded");
                else
                    Debug.Log(" Multiple Download Failed");

                Addressables.Release(updateHandle);
            }
            Addressables.Release(updateSizeHandle);
        }

        #endregion

        #region Clear Asset
        IEnumerator ClearAllAssetCoro()
        {
            foreach (var locats in Addressables.ResourceLocators)
            {
                var async = Addressables.ClearDependencyCacheAsync(locats.Keys, false);
                yield return async;
                Addressables.Release(async);
            }
            Caching.ClearCache();
        }

        IEnumerator ClearAssetCoro(string label)
        {
            var async = Addressables.LoadResourceLocationsAsync(label);
            yield return async;
            var locats = async.Result;
            foreach (var locat in locats)
                Addressables.ClearDependencyCacheAsync(locat.PrimaryKey);
        }

        IEnumerator ClearAssetCoro(AssetReference[] assets)
        {
            var async = Addressables.LoadResourceLocationsAsync(assets);
            yield return async;
            var locats = async.Result;
            foreach (var locat in locats)
                Addressables.ClearDependencyCacheAsync(locat.PrimaryKey);
        }
        #endregion
    }

}
