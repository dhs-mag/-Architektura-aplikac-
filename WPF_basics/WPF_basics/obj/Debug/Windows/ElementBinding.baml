   M S B A M L   `   `   `  ����E  AWPF_basics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPF_basics.WindowsWPF_basics.Windows  5   	   '    !WPF_basics.Windows.ElementBinding   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPF_basics.Windows     5   	     � Title$  ElementBinding��5   	   $��240.517��6    $	��375��61    � 	Resources 5
         Commands.Close��%   &	        �� 5   
   63   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6\    J� InputBindings 5      �� 5   
   
 �� Key$	 ESC��6    �� Command# [  6    6L   .��5      � .+�5   
   �� $��
10,10,10,0q�6   $��52��6)   $	��Top=�65   .+�5      �� -   5        $��	MyTextBox��5      � 5      $
��0,10q�6   .+�5      �� $��Value: ��6   $
��Bold"�6+   �� 5      ��6   ��  �� Path$
 Text� �� ElementName$ 	MyTextBox��5      5      � 5   
   $��
10,80,10,0q�6   $��30��6(   $	��Top=�64   .+�5      �� $��Window dimensions: ��6   �� 5      $��50��6R   ��6   �� *Width+	 �� UpdateSourceTrigger$	 PropertyChanged=�6R   �� 5       $	�� x ��6   �� 5!      $��50��6S   ��6   �� *Height+$	 PropertyChanged=�6S   5"      �� 5$   
   $��Close��6   #��[  6!   $��Right=�6K   $��	0,0,10,10q�6g   $	��130��6z   $��20��6�   $��Bottom=�6�   5%      5'      