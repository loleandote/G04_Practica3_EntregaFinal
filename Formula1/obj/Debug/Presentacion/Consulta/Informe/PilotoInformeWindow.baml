   M S B A M L   `   `   `  ����  Formula1"    Formula1.PilotoInformeWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  PilotoInformeWindow��5   	   $	��450��6%   $	��500��62   .��5	      � $��15q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $�� auto �6   �� 5      .+�5   
   �� $��Gran premio:��6   $��Center=�6'   $��Right=�6B   �� 5   
    �� DisplayMemberPath$ Valor��6:   $
��0,15q�6T   $��1��6�   $	��200��6�   $
��Left=�6�   ��6   �� *GrandesPremios+ �� SelectedItem 6b   �� *GranPremioSeleccionado+ �� UpdateSourceTrigger$ PropertyChanged=�6�   &   System.Windows.Controls.DataGrid  5   
   $��1��6f   $�� 2��6s   $�� auto��6�      
IsReadOnly .    AutoGenerateColumns .  $	��Top=�6�      CanUserAddRows .  	   RowHeaderWidth$	 0Q�6�   
   CanUserResizeRows
 .  ��6   �� *ClasificacionesEdicion+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Edicion��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Edicion+6R     5      $ Posicion��6%   $ * 6T    67   �� *
Posicion+6T     5      $ 
Puntuacion��6%   $ * 6X    69   �� *
Puntuacion+6X   5      �� 5   
   $��Año:��6   $�� 2��6   $��Center=�6-   $��Right=�6H   �� 5   
   $�� 2��6~   $��1��6�   $	��200��6�   $
��0,15q�6�   $
��Left=�6�   ��6   �� *Años+ 60   �� *AñoSeleccionado+$ PropertyChanged=�6�     5   
   $��3��6   $��2��6    $�� auto��6�    .  .  $	��Top=�6�    .  $	 0Q�6�   
 .  ��64   �� *ClasificacionesGranPremio+$ PropertyChanged=� 5         5!      $ Gran premio��6%   $ * 6Y    6:   �� *
GranPremio+6Y     5"      $ Posicion��6%   $
 auto 6T    67   �� *
Posicion+6T     5#      $ 
Puntuacion��6%   $
 auto 6X    69   �� *
Puntuacion+6X     5$      $ Vuelta Rápida��6%   $
 auto 6]    6<   �� *VueltaRapida+6]   5&      5'      5(      