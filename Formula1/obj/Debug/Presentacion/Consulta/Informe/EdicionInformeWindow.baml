   M S B A M L   `   `   `  ����  Formula1#    Formula1.EdicionInformeWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   $	��450��5   "   $	��650��6/     � Title  6	   �� *Titulo+.��5	      � $��15q�6    � RowDefinitions 5
   
   �� 5      $
��AUTO �6   �� 5      $��30 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Nombre:��6   �� 5   
   $��Ubicación:��6   $��2��6%   �� 5   
   $��	Longitud:��6   $��1��6$   �� 5   
   $��Curvas:��6   $��1��6"   $��2��6/   �� 5   
   $��1��64   ��6   �� *Circuito.Nombre+64   �� 5   
   $��3��6.   ��6   �� *	Ubicacion+6.   �� 5   
   $��1��66   $��1��6C   ��6   �� *Circuito.Longitud+6C   �� 5   
   $��1��64   $��3��6A   ��6   �� *Circuito.Curvas+6A   &   System.Windows.Controls.DataGrid  5   
   $��2��68   $��4��6E   $�� auto��6Y      
IsReadOnly .    AutoGenerateColumns .  $	��Top=�6�      CanUserAddRows .     RowHeaderWidth$ 0Q�6�      CanUserResizeRows .  ��6   �� *Participanes+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nombre��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Nombre+  5       $
	 Pais��6%   $	
 100 63    6?   �� *Pais+  5!      $	 	Posición��6%   $	
 100 67    6C   �� *
Posicion+  5"      $	 Puntos��6%   $	
 100 65    6A   �� *Puntos+5$      5%      5&      