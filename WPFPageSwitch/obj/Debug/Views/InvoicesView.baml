   M S B A M L   `   `   `  ����G  CJagoanFisika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFPageSwitch.ViewsWPFPageSwitch.Views  5      &     WPFPageSwitch.Views.InvoicesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFPageSwitch.Views     5      -   5          >�Name$  invoicesviewpage��5      .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 0.611Q�6-   5       � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $	��400 �6   �� 5      $��80 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��	30,20,0,0q�6(   $��Podsumowanie transakcji��6;   $��28(�6Z   $��Dubai)�6h   
�������6{   �� 5      $��1��6   $��	0,20,30,0q�6(   $��Janusz��6;   $��36(�6I   $��Magneto)�6W   
�������$��Right=�6   5      � 5   
   $��1��6    5       �� 5!      �� 5"      �� 5#      .+�5%      �� $��0��6   $��Drukuj raport:��6(   $��Center=�6>   $��Center=�6[   $��Dubai)�6v   
�������$��16(�6�   �� 5&      -   5        $��1��5&      $	��120��6'   $��20��63   $
��Left=�6?    �� SelectedItem 6�   ��  �� ElementName$ invoicesviewpage��	 �� Path$	 Selected_item�.@�5'      �� $��
za miesiac��6   �� 5(      $��za rok��6   �� 5)      $��calosc��6   5*      �� 5+      -   5        $��timePeriodComboBox��5+   ?   $��1��6   $	��120��6'   $��20��63   $��Right=�6Y   ��6u   �� $ invoicesviewpage��$	 time_period� 6�   �� $ invoicesviewpage��$	 Selected_item2��� 5,      -   5        $��printButton��5,   %   $��2��6   $��Drukuj��68   {�.  $��20��6o   $	��120��6{   5-      � 5.   
   $��2��6   .+�5/      �� -   5        $��transactionsList��5/   #   $��10q�6   
 �� View
 50      �� 51      .P�52      �� $��Id��6)    �� Width$ 30��65    �� DisplayMemberBinding 6@   �� *id+�� 53      $
��Data��6)   $	 130��67    6C   �� *
datetime+�� 54      $��Typ transakcji��6)   $	 130��6A    6M   �� *	tr_type+�� 55      $��Pojazd��6)   $	 130��69    6E   �� *car+�� 56      $��Kwota��6)   $	 130��68    6D   �� *price+�� 57      $��Saldo��6)   $	 100��68    6D   �� *	balance+�� 58      $��Akcje��6)   $	 120��68   -   5        testowe�� �� CellTemplate 59      �� 5:   "   .R�5;   &   ��  �� Orientation$ 
Horizontal=�61   .+�5<   *   �� -   5        $��Umowa��5<   1   $��50��6A   
����  �
�������$��Center=�6�   ��6�   �� *
filename+6�   �� 5=   *   -   5        $
��Usun��5=   1   $��50��6@   
���  ��
�������$��Center=�6�   ��6�   �� *id+6�   5>   '   5?   #   5A      5B      5D      5E      �� 5F   
   -	   5        $��
backButton��5F   /   $��3��6   $��Powrot��6   $��Right=�6|   
�������$	��100��6�   $��30��6�   $��
0,0,150,50q�6�   ��6V   �� *
filename+6�   5G      5H      