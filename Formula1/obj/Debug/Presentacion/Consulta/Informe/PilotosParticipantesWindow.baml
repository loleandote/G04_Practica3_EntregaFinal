   M S B A M L   `   `   `  ����  Formula1)    #Formula1.PilotosParticipantesWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   $	��450��5   "   $	��500��6/     � Title  6	   �� *Titulo+.��5	      � $	�� 15q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� ��6   �� *VueltaRapida+&   System.Windows.Controls.DataGrid  5   
   $��1��6   $�� auto��6H      
IsReadOnly .    AutoGenerateColumns .  $	��Top=�6�      CanUserAddRows .     RowHeaderWidth$ 0Q�6�      CanUserResizeRows .  ��6    �� *Clasificaciones+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *Piloto.Nombre+6W     5      $
 Pais��6%   
 63   �� *Piloto.Pais.Nombre+  5      $	  auto 6%   $ Posicion��63   
 6E   �� *
Posicion+5      5      5      