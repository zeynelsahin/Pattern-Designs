﻿
Context context = new Context();
ModifiedState modifiedState = new ModifiedState();
modifiedState.DoAction(context);
DeletedState deletedState = new DeletedState();
deletedState.DoAction(context);

Console.WriteLine(context.GetState().ToString());



interface IState
{
    void DoAction(Context context);
}

 class Context
{
    private IState _state;

    public void SetState(IState state)
    {
        _state = state;
    }

    public IState GetState()
    {;
        return _state;
    }
}

class ModifiedState:IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State : Modified");
        context.SetState(this);
    }

    public override string ToString()
    {
        return "Modified";
    }
}

class DeletedState:IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State : Deleted");
        context.SetState(this);
    }

}

class AddState:IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State : Added");
        context.SetState(this);
    }
    public override string ToString()
    {
        return "Added";
    }
}