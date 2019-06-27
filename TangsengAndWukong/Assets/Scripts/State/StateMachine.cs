using UnityEngine;

public class StateMachine<T>
{
    // 所属的智能体
    private T m_pOwner;
    // 当前状态
    private State<T> m_pCurrentState;
    private State<T> m_pPreviousState;
    // 每次FSM更新时，状态逻辑被调用
    private State<T> m_pGlobalState;

    public StateMachine(T obj)
    {
        m_pOwner = obj;
        m_pCurrentState = null;
        m_pPreviousState = null;
        m_pGlobalState = null;
    }

    public void SetCurrentState(State<T> s)
    {
        m_pCurrentState = s;
    }
    
    public void SetPreviousState(State<T> s)
    {
        m_pPreviousState = s;
    }
    
    public void SetGlobalState(State<T> s)
    {
        m_pGlobalState = s;
    }

    public State<T> GetCurrentState()
    {
        return m_pCurrentState;
    }
    
    public State<T> GetPreviousState()
    {
        return m_pPreviousState;
    }
    
    public State<T> GetGlobalState()
    {
        return m_pGlobalState;
    }
    
    // 更新
    public void Update ()
    {
        if (m_pGlobalState != null)
        {
            m_pGlobalState.Execute(m_pOwner);
        }

        if (m_pCurrentState != null)
        {
            m_pCurrentState.Execute(m_pOwner);
        }
    }
    
    // 更新状态
    public void ChangeState(State<T> s)
    {
        m_pPreviousState = m_pCurrentState;
        if (m_pCurrentState != null)
        {
            m_pCurrentState.Exit(m_pOwner);
        }
        
        m_pCurrentState = s;
        if (m_pCurrentState != null) {
            m_pCurrentState.Enter(m_pOwner);
        }
    }

    public bool isInState(State<T> s)
    {
        // TODO: 判断方式有待考究
        return s == m_pCurrentState;
    }
    
}