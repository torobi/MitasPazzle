using Adapter.IView;
using Domain.ITransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionView : MonoBehaviour, ITransitionView
{
    public void GoTo(Destination destination)
    {
        SceneManager.LoadScene(destination.ToString());
    }
}
