   M S B A M L   `   `   `  ����E  AWPF_basics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPF_basics.WindowsWPF_basics.Windows  5   	   =#clr-namespace:WPF_basics.ViewModelsWPF_basics.ViewModels  5   	   )    #WPF_basics.Windows.ViewModelBinding   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPF_basics.Windows     5   	   2vm#clr-namespace:WPF_basics.ViewModels     5   	     � Title$  ViewModelBinding��5	   	   $	��300��6"   $	��300��6/    � 	Resources 5
      3   -WPF_basics.ViewModels.BooleanToYesNoConverter   BooleanToYesNoConverter��%   &	          5   
   6%   5      .��5      � .+�5   
   �� $"��Number of travelers (Users):��6   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   �� 5   
   $
��Left=�6   $��
173,15,0,0q�6/   $
��Wrap=�6C   $	��Top=�6�   ��6W   �� *	Travelers+ �� FallbackValue$ 0��6�   �� 5   
   $��Ticket price:��6   $
��Left=�6(   $��	10,41,0,0q�6C   $	��Top=�6V   �� 5   
   $
��Left=�6   $��23��6-   $��	88,44,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6�   $��91��6�    �� TextAlignment$ Center=�6�   ��6`   �� *TicketPrice+ �� Mode$ TwoWay=�$ 0��6�   �� 5   
   $��Budget:��6   $
��Left=�6"   $��	10,69,0,0q�6=   $	��Top=�6P   �� 5   
   $
��Left=�6   $��23��6-   $��	88,72,0,0q�69   $
 Wrap=�6L   $	��Top=�6�   $��91��6�   $ Center=�6�   ��6`   �� *Budget+$ 0��$ TwoWay=�6�   �� 5   
   $��Travel cost:��6   $
��Left=�6'   $��
10,140,0,0q�6B   $	��Top=�6V   $
��Bold"�6n   �� 5   
   $
��Left=�6   $��
88,145,0,0q�6/   $
��Wrap=�6C   $	��Top=�6�   $��91��6�   $��21��6�   $
��Bold"�6�   ��6W   �� *
TravelCost+$ OneWay=�$ 0��6�   �� 5   
   $��Budget exceeded:��6   $
��Left=�6+   $��
10,171,0,0q�6F   $	��Top=�6Z   �� 5   
   $
��Left=�6   $��114,176,0,0q�6/   $
��Wrap=�6D   $	��Top=�6�   ��6X   �� *BudgetExceeded+$ OneWay=� �� 	Converter# [  $ No��6�   5      5      