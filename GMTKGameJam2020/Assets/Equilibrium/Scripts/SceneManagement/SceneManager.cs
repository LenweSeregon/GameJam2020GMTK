using System;
using UnityEngine.SceneManagement;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "SceneManager", menuName = "Equilibrium/SceneManager")]
    public class SceneManager : ScriptableObject
    {
        [SerializeField] private LoadingScreen m_prefabLoadingScreen;
        [NonSerialized] private LoadingScreen m_instantiatedLoadingScreen;
        
        public void LoadScene(string sceneName)
        {
            InstantiateLoadingScreen();
            
            m_instantiatedLoadingScreen.FadeIn(() => OnLoadingScreenFadeIn(sceneName));
        }

        private void OnLoadingScreenFadeIn(string sceneName)
        {
            m_instantiatedLoadingScreen.StartCoroutine(IeLoadScene(sceneName));
        }

        private IEnumerator IeLoadScene(string sceneName)
        {
            AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            while (op.isDone == false)
            {
                yield return null;
            }

            m_instantiatedLoadingScreen.FadeOut(null);
        }

        private void InstantiateLoadingScreen()
        {
            if (m_instantiatedLoadingScreen == null)
            {
                m_instantiatedLoadingScreen = Instantiate(m_prefabLoadingScreen);
                DontDestroyOnLoad(m_instantiatedLoadingScreen);
            }
        }
    } 
}

