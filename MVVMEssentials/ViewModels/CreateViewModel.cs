namespace MVVMEssentials.ViewModels; 

public delegate TVm CreateViewModel<TVm>() where TVm : BaseVm;
public delegate TVm CreateViewModel<TParameter, TVm>(TParameter parameter) where TVm : BaseVm;