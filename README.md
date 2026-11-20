# Pedidos de la Cafetería "El Buen Sabor"

## 1. Nombre y matrícula
- **Nombre:** Julio Sosa
- **Matrícula:** [2023-3904]

## 2. Descripción del programa
Aplicación de escritorio en C# (Windows Forms) con el formulario `frmPedidos` para registrar pedidos de la cafetería "El Buen Sabor", calcular recargos por tamaño o porción extra y obtener descuento de cliente frecuente, empaque, ITBIS y total a pagar.

## 3. Datos de entrada
- Nombre del cliente (`txtCliente`), fecha (`dtpFecha`) y casilla de cliente frecuente (`chkFrecuente`).
- Nombre del producto (`txtProducto`), precio unitario (`txtPrecio`), cantidad (`nudCantidad` del 1 al 20), tamaño (`rbtNormal` o `rbtGrande`), porción extra (`chkPorcionExtra`) y tipo de entrega (`rbtLocal` o `rbtLlevar`).

## 4. Proceso
- Al iniciar (`Load`), limpia los campos, deja los montos en `RD$ 0.00` y arma los encabezados (`Cant`, `Producto`, `Precio`, `Total`) en fuente Consolas usando `PadRight` y `PadLeft` con anchos 6, 24, 10 y 12.
- Al pulsar **Agregar al pedido**, suma +25 si es grande y +30 si lleva porción extra, calcula el total de la línea, añade la fila a `lstPedido`, acumula el subtotal y limpia los campos del producto.
- Al pulsar **Calcular total**, si no hay productos muestra aviso y no calcula; si hay productos, aplica 10% de descuento si es frecuente, suma RD$ 20 de empaque si es para llevar, calcula base imponible, 18% de ITBIS y total.
- **Nuevo pedido** limpia el formulario, reinicia el subtotal y enfoca `txtCliente`; **Salir** pide confirmación Sí/No antes de cerrar.

## 5. Salida
Muestra el detalle en `lstPedido` y los resultados en formato `RD$ 0.00` en `lblSubtotal`, `lblDescuento`, `lblEmpaque`, `lblItbis` y `lblTotal`.
Con el caso de prueba (María Pérez frecuente; Sándwich precio 180, cantidad 2, grande = 410.00; Jugo precio 120, cantidad 1, porción extra = 150.00; para llevar): subtotal `RD$ 560.00`, descuento `RD$ 56.00`, empaque `RD$ 20.00`, base `RD$ 524.00`, ITBIS `RD$ 94.32` y total `RD$ 618.32`.
